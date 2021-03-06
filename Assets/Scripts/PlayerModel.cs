using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;
using Normal.Realtime;

[RealtimeModel]
public partial class PlayerModel
{
    [RealtimeProperty(1, true, true)]
    private string _name;

    [RealtimeProperty(2, true, true)]
    private int _health;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class PlayerModel : RealtimeModel {
    public string name {
        get {
            return _nameProperty.value;
        }
        set {
            if (_nameProperty.value == value) return;
            _nameProperty.value = value;
            InvalidateReliableLength();
            FireNameDidChange(value);
        }
    }
    
    public int health {
        get {
            return _healthProperty.value;
        }
        set {
            if (_healthProperty.value == value) return;
            _healthProperty.value = value;
            InvalidateReliableLength();
            FireHealthDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(PlayerModel model, T value);
    public event PropertyChangedHandler<string> nameDidChange;
    public event PropertyChangedHandler<int> healthDidChange;
    
    public enum PropertyID : uint {
        Name = 1,
        Health = 2,
    }
    
    #region Properties
    
    private ReliableProperty<string> _nameProperty;
    
    private ReliableProperty<int> _healthProperty;
    
    #endregion
    
    public PlayerModel() : base(null) {
        _nameProperty = new ReliableProperty<string>(1, _name);
        _healthProperty = new ReliableProperty<int>(2, _health);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _nameProperty.UnsubscribeCallback();
        _healthProperty.UnsubscribeCallback();
    }
    
    private void FireNameDidChange(string value) {
        try {
            nameDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireHealthDidChange(int value) {
        try {
            healthDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _nameProperty.WriteLength(context);
        length += _healthProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _nameProperty.Write(stream, context);
        writes |= _healthProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Name: {
                    changed = _nameProperty.Read(stream, context);
                    if (changed) FireNameDidChange(name);
                    break;
                }
                case (uint) PropertyID.Health: {
                    changed = _healthProperty.Read(stream, context);
                    if (changed) FireHealthDidChange(health);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _name = name;
        _health = health;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
